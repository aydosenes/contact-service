﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DbContexTools
{
    public interface IDbSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
