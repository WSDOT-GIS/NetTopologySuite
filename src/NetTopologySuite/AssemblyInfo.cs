﻿using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

[assembly: AssemblyDelaySign(false)]
[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]
[assembly: Guid("6B7EB658-792E-4178-B853-8AEB851513A9")]
[assembly: SecurityRules(SecurityRuleSet.Level2, SkipVerificationInFullTrust = true)]

[assembly: InternalsVisibleTo("NetTopologySuite.Tests.NUnit, PublicKey=" + Consts.PublicKeyToken)]
