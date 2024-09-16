namespace BookStore.Domain.Books
{
    public class Category : Entity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        private Category() { }

        public static Category Create(string name)
        {
            Category category = new Category()
            {
                Name = name
            };

            return category;
        }

        public void UpdateName(string newName)
        {
            if (Name != newName)
            {
                Name = newName;
            }
        }
    }
}
