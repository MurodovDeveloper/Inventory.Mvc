using System.Runtime.Serialization;

namespace Inventory.Mvc.Controllers
{
    [Serializable]
    internal class NotFoundException : Exception
    {
        private string v;
        private object categoryName;

        public NotFoundException()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(string v, object categoryName)
        {
            this.v = v;
            this.categoryName = categoryName;
        }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}