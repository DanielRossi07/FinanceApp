namespace Finance.API.ApiModels.TransactionCategory
{
    public class UpdateTransactionCategoryApiInput
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public UpdateTransactionCategoryApiInput(string name, string? description = "")
        {
            Name = name;
            Description = description;
        }
    }
}
