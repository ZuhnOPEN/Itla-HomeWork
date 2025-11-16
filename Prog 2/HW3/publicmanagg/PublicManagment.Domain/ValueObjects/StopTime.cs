using System;

namespace PublicManagment.Domain.ValueObjects
{
    public sealed class StopTime
    {
        public Guid StopId { get; }
        public int Sequence { get; }
        public TimeSpan OffsetFromDeparture { get; }

        public StopTime(Guid stopId, int sequence, TimeSpan offsetFromDeparture)
        {
            if (stopId == Guid.Empty) throw new ArgumentException("StopId is required", nameof(stopId));
            if (sequence < 0) throw new ArgumentOutOfRangeException(nameof(sequence), "Sequence must be zero or positive.");
            if (offsetFromDeparture < TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(offsetFromDeparture), "Offset must be zero or positive.");

            StopId = stopId;
            Sequence = sequence;
            OffsetFromDeparture = offsetFromDeparture;
        }
    }
}