namespace CourseContentManagement.Exceptions
{
    public class NotEntityOwnerException : Exception
    {
        public NotEntityOwnerException(string entity, int id, int userId)
        : base($"{entity} wtih id={id} is not owner by user with id={userId}")
        {

        }
    }
}