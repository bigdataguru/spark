﻿/* 
 * Copyright (c) 2014, Furore (info@furore.com) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.github.com/furore-fhir/spark/master/LICENSE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spark.Search.Mongo
{
    public interface ITerm
    {
        string Resource { get; set; }
        string Field { get; set; }
        string Operator { get; set; }
        string Value { get; set; }
        Argument Argument { get; set; }
    }
}