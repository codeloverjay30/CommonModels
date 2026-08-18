namespace CommonModels
{
    public class FileModel
    {
        private readonly IFileExtensionMapper _mapper;
        public string RealFullPath { get; private set; }

        public string FileName => System.IO.Path.GetFileName(RealFullPath);
        public string FileExtension => System.IO.Path.GetExtension(RealFullPath);

        // 透過接口取得對應類型
        public string FileExtensionType => _mapper.GetTypeName(FileExtension);

        // 在建構函式要求傳入實作，若未傳入則可給予預設值
        public FileModel(
            string realFullPath ,
            IFileExtensionMapper mapper = null
        )
        {
            this.RealFullPath = realFullPath;
            // 如果沒給 mapper，使用預設實作（或拋出異常，視架構而定）
            this._mapper = mapper ?? new DefaultFileExtensionMapper();
        }
    }
}
