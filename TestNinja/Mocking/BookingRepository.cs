using System.Linq;

namespace TestNinja.Mocking
{
    public interface IBookingRepository
    {
        IQueryable<BookingClass> GetActiveBookings(int? excludedBookingId);
    }

    public class BookingRepository : IBookingRepository
    {
        public IQueryable<BookingClass> GetActiveBookings(int? excludedBookingId)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
                unitOfWork.Query<BookingClass>().Where(x => x.Status != "Cancelled");

            if (excludedBookingId.HasValue)
                bookings = bookings.Where(x => x.Id != excludedBookingId.Value);

            return bookings;
        }

    }
}
