using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples_Examples
{
    public enum Relation
    {
        Parent,
        Child
    }

    public class Person
    {
        public string Name { get; set; }    
    }

    public interface IReleationship
    {
        IEnumerable<Person> FindChildOf(string name);
    }

    public class Relationship: IReleationship
    {
        private List<(Person, Relation, Person)> Relationships = new List<(Person, Relation, Person)>();

        public void AssignRelation(Person parent, Relation relation, Person child)
        {
            Relationships.Add((parent, relation, child));
        }

        public IEnumerable<Person> FindChildOf(string name)
        {
            foreach(var relationship in Relationships)
            {
                if (relationship.Item1.Name == name
                    && relationship.Item2 == Relation.Parent)
                    yield return relationship.Item3;
            }
        }
    }

    public class Research
    {
        private IReleationship releationship;

        public Research(IReleationship relationship)
        {
            this.releationship = relationship;
        }

        public void ShowRelationsForParent()
        {
            Relationship relationship = new Relationship();
            relationship.AssignRelation(new Person() { Name = "Ayyappan" }, Relation.Parent, new Person() { Name = "Ishaan" });
            relationship.AssignRelation(new Person() { Name = "Ayyappan" }, Relation.Parent, new Person() { Name = "Ishita" });
            
            foreach(Person p in relationship.FindChildOf("Ayyappan"))
            {
                Console.WriteLine($"Child Name is: {p.Name}");
            }
        }
    }
}
