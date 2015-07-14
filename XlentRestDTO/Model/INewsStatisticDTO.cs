using System;

namespace DTOModel.Model
{
    public interface INewsStatisticDTO
    {
        string NewsId { get; set; }

        string UserId { get; set; }

        DateTime TimeStartedReading { get; set; }

        DateTime TimeFinnishedReading { get; set; }

        string Id { get; set; }
    }
}