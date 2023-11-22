namespace RefactoringToPatterns.CreationMethods
{
    public interface ProductService
    {
        string _internetLabel;
        private readonly int? _telephoneNumber;
        private readonly string[] _tvChannels;
        
        public ProductService(string internetLabel)
        {
            _internetLabel = internetLabel;
        }
    }
}