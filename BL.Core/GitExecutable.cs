﻿using BL.Core;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BL.Core;

public class GitExecutable(string gitPath, ILogger logger, ProcessStartInfo psi)
    : ExecuteableBase(gitPath, "git.exe", logger, psi);

