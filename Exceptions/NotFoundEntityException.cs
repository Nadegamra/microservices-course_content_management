namespace CourseContentManagement.Exceptions
{
    public class NotFoundEntityException : Exception
    {
        public NotFoundEntityException(string entity, int id)
        : base($"{entity} with id={id} not found")
        {

        }
    }
}