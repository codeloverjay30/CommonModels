using System.ComponentModel;

namespace CommonModels
{
    [Serializable]
    [Description("execution status")]
    public class StatusJsonModel
    {
        [Description("UUID of the execution status")]
        public int Id { get; set; }
        [Description("Name or executing method name")]
        public string Name { get; set; }

        [Description("Category")]
        public string CategoryName { get; set; }
        [Description("Description of execution status")]
        public string Description { get; set; }

        [Description("success or not")]
        public bool IsSuccess { get; set; }

        [Description("execution result")]
        public string Result { get; set; }

        [Description("Data source used for API")]
        public string DataSource { get; set; }

        [Description("Error message")]
        public string ErrorMessage { get; set; }

        [Description("Overall of error message")]
        public string OverallErrorMessage { get; set; }

        [Description("Details of error message")]
        public string DetailedErrorMessage { get; set; }

        [Description("Metadata related to execution result")]
        public Dictionary<string , string> Metadata { get; set; } = new();

        [Description("The error log will be logged to")]
        public FileModel File { get; set; }
        public StatusJsonModel()
        {
            this.Init();
        }

        private void Init()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.CategoryName = string.Empty;
            this.Description = string.Empty;
            this.IsSuccess = false;
            this.Result = string.Empty;
            this.ErrorMessage = string.Empty;
            this.OverallErrorMessage = string.Empty;
            this.DetailedErrorMessage = string.Empty;
            this.File = new FileModel(string.Empty);
        }
    }
}
