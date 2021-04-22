﻿using System;
using System.Linq;

namespace NStandard.Reference
{
    //TODO: Long-term Maintenance
    //TODO: To support more frameworks
    //Refer: https://docs.microsoft.com/en-us/nuget/reference/target-frameworks
    public class DotNetFramework
    {
        public string Name;
        public string Abbreviation;
        /// <summary>
        /// Target Framework Moniker
        /// </summary>
        public string TFM;
        public Version Version;
        public bool Supported;
        public DotNetFramework[] CompatibilityFrameworks;

        internal DotNetFramework(string name, string abbreviation, string tfm, Version version, bool supported)
        {
            Name = name;
            Abbreviation = abbreviation;
            TFM = tfm;
            Version = version;
            Supported = supported;
        }

        public override string ToString() => TFM;

        public static DotNetFramework NetStandard10 = new(".NET Standard", "netstandard", "netstandard1.0", new Version(1, 0, 0), true);
        public static DotNetFramework NetStandard11 = new(".NET Standard", "netstandard", "netstandard1.1", new Version(1, 1, 0), true);
        public static DotNetFramework NetStandard12 = new(".NET Standard", "netstandard", "netstandard1.2", new Version(1, 2, 0), true);
        public static DotNetFramework NetStandard13 = new(".NET Standard", "netstandard", "netstandard1.3", new Version(1, 3, 0), true);
        public static DotNetFramework NetStandard14 = new(".NET Standard", "netstandard", "netstandard1.4", new Version(1, 4, 0), true);
        public static DotNetFramework NetStandard15 = new(".NET Standard", "netstandard", "netstandard1.5", new Version(1, 5, 0), true);
        public static DotNetFramework NetStandard16 = new(".NET Standard", "netstandard", "netstandard1.6", new Version(1, 6, 0), true);
        public static DotNetFramework NetStandard20 = new(".NET Standard", "netstandard", "netstandard2.0", new Version(2, 0, 0), true);
        public static DotNetFramework NetStandard21 = new(".NET Standard", "netstandard", "netstandard2.1", new Version(2, 1, 0), true);

        public static DotNetFramework NetCoreApp10 = new(".NET Core App", "netcoreapp", "netcoreapp1.0", new Version(1, 0, 0), true);
        public static DotNetFramework NetCoreApp11 = new(".NET Core App", "netcoreapp", "netcoreapp1.1", new Version(1, 1, 0), true);
        public static DotNetFramework NetCoreApp20 = new(".NET Core App", "netcoreapp", "netcoreapp2.0", new Version(2, 0, 0), true);
        public static DotNetFramework NetCoreApp21 = new(".NET Core App", "netcoreapp", "netcoreapp2.1", new Version(2, 1, 0), true);
        public static DotNetFramework NetCoreApp22 = new(".NET Core App", "netcoreapp", "netcoreapp2.2", new Version(2, 2, 0), true);
        public static DotNetFramework NetCoreApp30 = new(".NET Core App", "netcoreapp", "netcoreapp3.0", new Version(3, 0, 0), true);
        public static DotNetFramework NetCoreApp31 = new(".NET Core App", "netcoreapp", "netcoreapp3.1", new Version(3, 1, 0), true);

        public static DotNetFramework Net11 = new(".NET Framework", "net", "net11", new Version(1, 1, 0), true);
        public static DotNetFramework Net20 = new(".NET Framework", "net", "net20", new Version(2, 0, 0), true);
        public static DotNetFramework Net35 = new(".NET Framework", "net", "net35", new Version(3, 5, 0), true);
        public static DotNetFramework Net40 = new(".NET Framework", "net", "net40", new Version(4, 0, 0), true);
        public static DotNetFramework Net403 = new(".NET Framework", "net", "net403", new Version(4, 0, 3), true);
        public static DotNetFramework Net45 = new(".NET Framework", "net", "net45", new Version(4, 5, 0), true);
        public static DotNetFramework Net451 = new(".NET Framework", "net", "net451", new Version(4, 5, 1), true);
        public static DotNetFramework Net452 = new(".NET Framework", "net", "net452", new Version(4, 5, 2), true);
        public static DotNetFramework Net46 = new(".NET Framework", "net", "net46", new Version(4, 6, 0), true);
        public static DotNetFramework Net461 = new(".NET Framework", "net", "net461", new Version(4, 6, 1), true);
        public static DotNetFramework Net462 = new(".NET Framework", "net", "net462", new Version(4, 6, 2), true);
        public static DotNetFramework Net47 = new(".NET Framework", "net", "net47", new Version(4, 7, 0), true);
        public static DotNetFramework Net471 = new(".NET Framework", "net", "net471", new Version(4, 7, 1), true);
        public static DotNetFramework Net472 = new(".NET Framework", "net", "net472", new Version(4, 7, 2), true);
        public static DotNetFramework Net48 = new(".NET Framework", "net", "net48", new Version(4, 8, 0), true);

        // .NET 5.0 and later has NetCoreApp identifier
        public static DotNetFramework Net50 = new(".NET Core App", "netcoreapp", "netcoreapp5.0", new Version(5, 0, 0), true);
        public static DotNetFramework Net60 = new(".NET Core App", "netcoreapp", "netcoreapp6.0", new Version(6, 0, 0), true);

        static DotNetFramework()
        {
            static DotNetFramework[] CombineFrameworks(DotNetFramework[] @new, DotNetFramework compatibility)
            {
                return @new.Concat(compatibility.CompatibilityFrameworks).ToArray();
            }

            NetStandard10.CompatibilityFrameworks = new[] { NetStandard10 };
            NetStandard11.CompatibilityFrameworks = CombineFrameworks(new[] { NetStandard11 }, NetStandard10);
            NetStandard12.CompatibilityFrameworks = CombineFrameworks(new[] { NetStandard12 }, NetStandard11);
            NetStandard13.CompatibilityFrameworks = CombineFrameworks(new[] { NetStandard13 }, NetStandard12);
            NetStandard14.CompatibilityFrameworks = CombineFrameworks(new[] { NetStandard14 }, NetStandard13);
            NetStandard15.CompatibilityFrameworks = CombineFrameworks(new[] { NetStandard15 }, NetStandard14);
            NetStandard16.CompatibilityFrameworks = CombineFrameworks(new[] { NetStandard16 }, NetStandard15);
            NetStandard20.CompatibilityFrameworks = CombineFrameworks(new[] { NetStandard20 }, NetStandard16);
            NetStandard21.CompatibilityFrameworks = CombineFrameworks(new[] { NetStandard21 }, NetStandard20);

            NetCoreApp10.CompatibilityFrameworks = new[] { NetCoreApp10, NetStandard10 };
            NetCoreApp11.CompatibilityFrameworks = CombineFrameworks(new[] { NetCoreApp11 }, NetCoreApp10);
            NetCoreApp20.CompatibilityFrameworks = CombineFrameworks(new[] { NetCoreApp20, NetStandard20 }, NetCoreApp11);
            NetCoreApp21.CompatibilityFrameworks = CombineFrameworks(new[] { NetCoreApp21 }, NetCoreApp20);
            NetCoreApp22.CompatibilityFrameworks = CombineFrameworks(new[] { NetCoreApp22 }, NetCoreApp21);
            NetCoreApp30.CompatibilityFrameworks = CombineFrameworks(new[] { NetCoreApp30, NetStandard21 }, NetCoreApp22);
            NetCoreApp31.CompatibilityFrameworks = CombineFrameworks(new[] { NetCoreApp31 }, NetCoreApp30);

            Net11.CompatibilityFrameworks = new[] { Net11 };
            Net20.CompatibilityFrameworks = CombineFrameworks(new[] { Net20 }, Net11);
            Net35.CompatibilityFrameworks = CombineFrameworks(new[] { Net35 }, Net20);
            Net40.CompatibilityFrameworks = CombineFrameworks(new[] { Net40 }, Net35);
            Net403.CompatibilityFrameworks = CombineFrameworks(new[] { Net403 }, Net40);
            Net45.CompatibilityFrameworks = CombineFrameworks(new[] { Net45, NetStandard11, NetStandard10 }, Net403);
            Net451.CompatibilityFrameworks = CombineFrameworks(new[] { Net451, NetStandard12 }, Net45);
            Net452.CompatibilityFrameworks = CombineFrameworks(new[] { Net452 }, Net451);
            Net46.CompatibilityFrameworks = CombineFrameworks(new[] { Net46, NetStandard13 }, Net452);
            Net461.CompatibilityFrameworks = CombineFrameworks(new[] { Net461, NetStandard20, NetStandard16, NetStandard15, NetStandard14, Net46 }, Net46);
            Net462.CompatibilityFrameworks = CombineFrameworks(new[] { Net462 }, Net461);
            Net47.CompatibilityFrameworks = CombineFrameworks(new[] { Net47 }, Net462);
            Net471.CompatibilityFrameworks = CombineFrameworks(new[] { Net471 }, Net47);
            Net472.CompatibilityFrameworks = CombineFrameworks(new[] { Net472 }, Net471);
            Net48.CompatibilityFrameworks = CombineFrameworks(new[] { Net48 }, Net472);
        }

        public static readonly DotNetFramework[] SupportedFrameworks = new[]
        {
            NetStandard10, NetStandard11, NetStandard12, NetStandard13, NetStandard14, NetStandard15, NetStandard16,
            NetStandard20, NetStandard21,
            NetCoreApp10, NetCoreApp11,
            NetCoreApp20, NetCoreApp21, NetCoreApp22,
            NetCoreApp30, NetCoreApp31,
            Net11, Net20, Net35,
            Net40, Net403, Net45, Net451, Net452, Net46, Net461, Net462, Net47, Net471, Net472, Net48,
        };

        public static DotNetFramework Parse(string tfm)
        {
            var framework = SupportedFrameworks.FirstOrDefault(x => x.TFM == tfm);
            if (framework is null)
                throw new NotSupportedException($"The TFM ({tfm}) dose not exist or temporarily does not support.");
            else return framework;
        }

    }
}
