using Core.Persistence.Repositories;

namespace Domain.Entites
{
    public class ProgrammingLanguage : Entity
    {
        public string Name { get; set; }
        public int PublicationDate { get; set; }

        public ProgrammingLanguage()
        {

        }

        public ProgrammingLanguage(int id, string name, int publicationDate) : this()
        {
            Id = id;
            Name = name;
            PublicationDate = publicationDate;
        }
    }
}
