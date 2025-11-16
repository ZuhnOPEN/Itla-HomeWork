using System;
using System.Collections.Generic;
using System.Linq;
using PublicManagment.Domain.Common;
using PublicManagment.Domain.ValueObjects;

namespace PublicManagment.Domain.Entities
{
    public sealed class Trip : AggregateRoot
    {
        public Guid LineId { get; private set; }
        public Guid VehicleId { get; private set; }
        public Guid? DriverId { get; private set; }
        public DateTimeOffset Departure { get; private set; }

        private List<StopTime> _stopTimes = new();
        public IReadOnlyList<StopTime> StopTimes => _stopTimes.AsReadOnly();

        public Trip(Guid? id, Guid lineId, Guid vehicleId, DateTimeOffset departure, IEnumerable<StopTime>? stopTimes = null, Guid? driverId = null) : base(id)
        {
            if (lineId == Guid.Empty) throw new ArgumentException("LineId is required", nameof(lineId));
            if (vehicleId == Guid.Empty) throw new ArgumentException("VehicleId is required", nameof(vehicleId));
            if (departure == default) throw new ArgumentException("Departure is required", nameof(departure));

            LineId = lineId;
            VehicleId = vehicleId;
            Departure = departure;
            DriverId = driverId;
            _stopTimes = stopTimes?.OrderBy(st => st.Sequence).ToList() ?? new List<StopTime>();
        }

        public Trip(Guid lineId, Guid vehicleId, DateTimeOffset departure, IEnumerable<StopTime>? stopTimes = null, Guid? driverId = null)
            : this(null, lineId, vehicleId, departure, stopTimes, driverId) { }

        public void AssignDriver(Guid driverId)
        {
            if (driverId == Guid.Empty) throw new ArgumentException("DriverId is required", nameof(driverId));
            DriverId = driverId;
        }

        public void ChangeDeparture(DateTimeOffset newDeparture)
        {
            if (newDeparture == default) throw new ArgumentException("Departure is required", nameof(newDeparture));
            Departure = newDeparture;
        }

        public void SetStopTimes(IEnumerable<StopTime> times)
        {
            if (times == null) throw new ArgumentNullException(nameof(times));
            _stopTimes.Clear();
            _stopTimes.AddRange(times.OrderBy(t => t.Sequence));
        }
    }
}