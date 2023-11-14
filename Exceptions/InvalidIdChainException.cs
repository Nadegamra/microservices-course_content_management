namespace CourseContentManagement.Exceptions
{
    public class InvalidIdChainException : Exception
    {
        public InvalidIdChainException(string entity1, int id1, string entity2, int id2)
        : base($"{entity1} with id={id1} does not have {entity2} with id={id2}")
        {

        }
    }
}