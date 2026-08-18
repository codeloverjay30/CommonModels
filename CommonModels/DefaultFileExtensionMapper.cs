namespace CommonModels
{
    public class DefaultFileExtensionMapper : IFileExtensionMapper
    {
        // 將原本 MappingTables 的邏輯搬過來
        private static readonly Dictionary<string , string> _mappingTable = new()
        {
            [ ".pdf" ] = "PDF" ,
            [ ".xlsx" ] = "Excel" ,
            [ ".xls" ] = "Excel" ,
            [ ".csv" ] = "Worksheet" ,
            [ ".docx" ] = "Word" ,
            [ ".doc" ] = "Word" ,
            [ ".ods" ] = "Word" ,
        };

        public string GetTypeName(string extension)
        {
            if(_mappingTable.TryGetValue(extension , out string typeName))
            {
                return typeName;
            }
            return string.Empty;
        }
    }
}
