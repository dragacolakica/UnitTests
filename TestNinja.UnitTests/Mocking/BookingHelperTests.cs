using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests_OverlappingBookingsExist
    {
        private BookingClass _booking;
        private Mock<IBookingRepository> _bookRepo;

        [SetUp]
        public void SetUp()
        {
            _booking = new BookingClass()
            {
                Id = 1,
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DepartOn(2017, 1, 20),
                Reference = "a"
            };
            _bookRepo = new Mock<IBookingRepository>();
            _bookRepo.Setup(x => x.GetActiveBookings(1)).Returns(new List<BookingClass>
            {
             _booking
            }.AsQueryable());
        }

        [Test]
        public void BookingStartsAndFinishesBefore()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new BookingClass()
                {
                    Id = 1,
                    ArrivalDate = Before(_booking.ArrivalDate, days: 2),
                    DepartureDate = After(_booking.ArrivalDate),
                    Reference = "a"
                }, _bookRepo.Object);

            Assert.That(result, Is.EqualTo(_booking.Reference));
        }

        [Test]
        public void BookingStartsBeforeAndFinishesInMiddleBooking()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new BookingClass()
                {
                    Id = 1,
                    ArrivalDate = Before(_booking.ArrivalDate),
                    DepartureDate = After(_booking.ArrivalDate),
                    Reference = "a"
                }, _bookRepo.Object);

            Assert.That(result, Is.EqualTo(_booking.Reference));
        }


        [Test]
        public void BookingStartsBeforeAndFinishesAfter()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new BookingClass()
                {
                    Id = 1,
                    ArrivalDate = Before(_booking.ArrivalDate),
                    DepartureDate = After(_booking.DepartureDate),
                    Reference = "a"
                }, _bookRepo.Object);

            Assert.That(result, Is.EqualTo(_booking.Reference));
        }

        [Test]
        public void BookingStartsAndFinishesInMiddle()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new BookingClass()
                {
                    Id = 1,
                    ArrivalDate = After(_booking.ArrivalDate),
                    DepartureDate = Before(_booking.DepartureDate),
                    Reference = "a"
                }, _bookRepo.Object);

            Assert.That(result, Is.EqualTo(_booking.Reference));
        }

        [Test]
        public void BookingStartsInMiddleAndFinishesAfter()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new BookingClass()
                {
                    Id = 1,
                    ArrivalDate = Before(_booking.ArrivalDate),
                    DepartureDate = After(_booking.DepartureDate),
                    Reference = "a"
                }, _bookRepo.Object);

            Assert.That(result, Is.EqualTo(_booking.Reference));
        }

        [Test]
        public void BookingStartsAndFinishesAfter()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new BookingClass()
                {
                    Id = 1,
                    ArrivalDate = After(_booking.DepartureDate, days: 2),
                    DepartureDate = After(_booking.DepartureDate, days: 2),
                    Reference = "a"
                }, _bookRepo.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void BookingsOverlap_BookingCancelled()
        {
            var result = BookingHelper.OverlappingBookingsExist(
                new BookingClass()
                {
                    Id = 1,
                    ArrivalDate = Before(_booking.ArrivalDate),
                    DepartureDate = After(_booking.DepartureDate),
                    Reference = "a",
                    Status = "Cancelled"
                }, _bookRepo.Object);

            Assert.That(result, Is.Empty);
        }
        private DateTime Before(DateTime date, int days = -1)
        {
            return date.AddDays(days);
        }
        private DateTime After(DateTime date, int days = 1)
        {
            return date.AddDays(days);
        }
        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
    }
}
