using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels
{
    public static partial class MappingTables
    {
        public static Dictionary<string , string> FileExtensionTypeMappingTable
        {
            get
            {
                return new Dictionary<string , string>()
                {
                    [ ".pdf" ] = "PDF" ,
                    [ ".xlsx" ] = "Excel" ,
                    [ ".xls" ] = "Excel" ,
                    [ ".csv" ] = "Worksheet" ,
                    [ ".docx" ] = "Word" ,
                    [ ".doc" ] = "Word" ,
                    [ ".ods" ] = "Word" ,
                };
            }
        }
    }
}
