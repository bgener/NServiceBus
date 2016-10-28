namespace NServiceBus.Core.Tests.AssemblyScanner
{
    using System;
    using System.CodeDom.Compiler;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Hosting.Helpers;
    using Microsoft.CSharp;
    using NUnit.Framework;

    [TestFixture]
    public class AssemblyScannerTests
    {
        public static string GetTestAssemblyDirectory()
        {
            var directoryName = GetAssemblyDirectory();
            return Path.Combine(directoryName, "TestDlls");
        }

        public static string GetAssemblyDirectory()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        [Test]
        public void System_assemblies_should_be_excluded()
        {
            Assert.IsTrue(AssemblyScanner.IsRuntimeAssembly(typeof(string).Assembly.Location));
            Assert.IsTrue(AssemblyScanner.IsRuntimeAssembly(typeof(Uri).Assembly.Location));
            Assert.IsTrue(AssemblyScanner.IsRuntimeAssembly(new AssemblyName("mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e, Retargetable=Yes")));
        }

        [Test]
        public void Non_system_assemblies_should_be_included()
        {
            Assert.IsFalse(AssemblyScanner.IsRuntimeAssembly(GetType().Assembly.Location));
        }


        [Test]
        public void ReferencesNServiceBus_requires_binding_redirect()
        {
            var combine = Path.Combine(GetTestAssemblyDirectory(), "AssemblyWithRefToSN.dll");
            Assert.IsTrue(AssemblyScanner.ReferencesNServiceBus(combine));
        }

        [Test]
        public void ReferencesNServiceBus_returns_false_for_no_reference()
        {
            var combine = Path.Combine(GetTestAssemblyDirectory(), "dotNet.dll");
            Assert.IsFalse(AssemblyScanner.ReferencesNServiceBus(combine));
        }

        [Test]
        public void Assemblies_with_direct_reference_are_included()
        {
            var busAssembly = new DynamicAssembly("NServiceBus.Core.dll");
            var assemblyWithReference = new DynamicAssembly("AssemblyWithReference.dll", new[] { busAssembly });

            using (var dynamicDirectory = new DynamicAssemblyDirectory(busAssembly, assemblyWithReference))
            {
                var scanner = new AssemblyScanner(dynamicDirectory);
                var result = scanner.GetScannableAssemblies();

                Assert.AreEqual(2, result.Assemblies.Count);
                Assert.IsTrue(result.Assemblies.Contains(assemblyWithReference));
                Assert.IsTrue(result.Assemblies.Contains(busAssembly));
            }
        }

        [Test]
        public void Assemblies_with_no_reference_are_excluded()
        {
            var busAssembly = new DynamicAssembly("NServiceBus.Core.dll");
            var assemblyWithReference = new DynamicAssembly("AssemblyWithReference.dll", new[] { busAssembly });
            var assemblyWithoutReference = new DynamicAssembly("AssemblyWithoutReference.dll");

            using (var dynamicDirectory = new DynamicAssemblyDirectory(busAssembly, assemblyWithReference, assemblyWithoutReference))
            {
                var scanner = new AssemblyScanner(dynamicDirectory);
                var result = scanner.GetScannableAssemblies();

                Assert.AreEqual(2, result.Assemblies.Count);
                Assert.IsTrue(result.Assemblies.Contains(assemblyWithReference));
                Assert.IsTrue(result.Assemblies.Contains(busAssembly));
                Assert.IsFalse(result.Assemblies.Contains(assemblyWithoutReference));
            }
        }

        [Test]
        public void Assemblies_which_reference_older_nsb_version_are_included()
        {
            var busAssemblyV1 = new DynamicAssembly("NServiceBus.Core.dll", version: new Version(1, 0, 0));
            var busAssemblyV2 = new DynamicAssembly("NServiceBus.Core.dll", version: new Version(2, 0, 0));
            var assemblyReferencesV1 = new DynamicAssembly("AssemblyWithReference1.dll", new[] { busAssemblyV1 });
            var assemblyReferencesV2 = new DynamicAssembly("AssemblyWithReference2.dll", new[] { busAssemblyV2 });

            using (var dynamicDirectory = new DynamicAssemblyDirectory(busAssemblyV1, busAssemblyV2, assemblyReferencesV1, assemblyReferencesV2))
            {
                var scanner = new AssemblyScanner(dynamicDirectory);
                var result = scanner.GetScannableAssemblies();

                Assert.AreEqual(3, result.Assemblies.Count);
                Assert.IsTrue(result.Assemblies.Contains(assemblyReferencesV1));
                Assert.IsTrue(result.Assemblies.Contains(assemblyReferencesV2));
            }
        }

        [Test]
        public void Assemblies_with_transitive_reference_are_include()
        {
            var busAssembly = new DynamicAssembly("NServiceBus.Core.dll");
            var assemblyC = new DynamicAssembly("C.dll", new[] { busAssembly });
            var assemblyB = new DynamicAssembly("B.dll", new[] { assemblyC });
            var assemblyA = new DynamicAssembly("A.dll", new[] { assemblyB });
            var assemblyD = new DynamicAssembly("D.dll", new[] { assemblyB });

            using (var dynamicDirectory = new DynamicAssemblyDirectory(assemblyA, assemblyB, assemblyC, assemblyD, busAssembly))
            {
                var scanner = new AssemblyScanner(dynamicDirectory);
                var result = scanner.GetScannableAssemblies();

                Assert.AreEqual(5, result.Assemblies.Count);
                Assert.IsTrue(result.Assemblies.Contains(assemblyA));
                Assert.IsTrue(result.Assemblies.Contains(assemblyB));
                Assert.IsTrue(result.Assemblies.Contains(assemblyC));
                Assert.IsTrue(result.Assemblies.Contains(assemblyD));
            }
        }

        class DynamicAssemblyDirectory : IDisposable
        {
            DynamicAssembly[] dynamicAssemblies;

            public DynamicAssemblyDirectory(params DynamicAssembly[] assemblies)
            {
                dynamicAssemblies = assemblies;
                Directory = assemblies.Select(a => Path.GetDirectoryName(a.FilePath)).Distinct().Single();
            }

            public string Directory
            {
                get;
            }

            public void Dispose()
            {
                foreach (var dynamicAssembly in dynamicAssemblies)
                {
                    dynamicAssembly.Dispose();
                }
            }

            public static implicit operator string(DynamicAssemblyDirectory directory)
            {
                return directory.Directory;
            }
        }
        class DynamicAssembly : IDisposable
        {
            public string Namespace { get; }

            public string Name { get; }

            public string FileName { get; }
            public string FilePath { get; }

            public Assembly Assembly { get; }

            public DynamicAssembly(string nameWithExtension, DynamicAssembly[] references = null, Version version = null)
            {
                if (version == null)
                {
                    version = new Version(1, 0, 0, 0);
                }

                if (references == null)
                {
                    references = new DynamicAssembly[0];
                }

                Name = nameWithExtension;
                Namespace = Path.GetFileNameWithoutExtension(nameWithExtension);
                FileName = nameWithExtension;
                var builder = new StringBuilder();
                builder.AppendLine("using System.Reflection;");
                builder.AppendLine($"[assembly: AssemblyVersion(\"{version}\")]");
                builder.AppendLine($"[assembly: AssemblyFileVersion(\"{version}\")]");

                builder.AppendFormat("namespace {0} {{ ", Namespace);

                var provider = new CSharpCodeProvider();
                var param = new CompilerParameters(new string[] { }, nameWithExtension);
                param.GenerateExecutable = false;
                param.OutputAssembly = FilePath = Path.Combine(GetTestAssemblyDirectory(), FileName);
                param.TempFiles = new TempFileCollection(GetTestAssemblyDirectory(), false);

                foreach (var reference in references)
                {
                    builder.AppendLine($"using {reference.Namespace};");
                    param.ReferencedAssemblies.Add(reference.Assembly.Location);
                }


                builder.AppendLine("public class Foo { public Foo() {");
                foreach (var reference in references)
                {
                    builder.AppendLine($"new {reference.Namespace}.Foo();");
                }
                builder.AppendLine("} } }");

                var result = provider.CompileAssemblyFromSource(param, builder.ToString());
                ThrowIfCompilationWasNotSuccessful(result);
                Assembly = result.CompiledAssembly;
            }

            static string GetTestAssemblyDirectory()
            {
                var directoryName = GetAssemblyDirectory();
                var directory = Path.Combine(directoryName, "assemblyscannerfiles");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                return directory;
            }

            static string GetAssemblyDirectory()
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }

            static void ThrowIfCompilationWasNotSuccessful(CompilerResults results)
            {
                if (results.Errors.HasErrors)
                {
                    var errors = new StringBuilder("Compiler Errors :\r\n");
                    foreach (CompilerError error in results.Errors)
                    {
                        errors.AppendFormat("Line {0},{1}\t: {2}\n",
                            error.Line, error.Column, error.ErrorText);
                    }
                    throw new Exception(errors.ToString());
                }
            }

            public static implicit operator Assembly(DynamicAssembly dynamicAssembly)
            {
                return dynamicAssembly.Assembly;
            }

            public void Dispose()
            {
                File.Delete(FilePath);
            }
        }
    }
}