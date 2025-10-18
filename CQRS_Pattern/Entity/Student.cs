namespace CQRS_Pattern.Entity
{
    public class Student
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
