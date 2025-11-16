using System;
using PublicManagment.Domain.Common;
using PublicManagment.Domain.ValueObjects;

namespace PublicManagment.Domain.Entities
{
    public sealed class Stop : Entity
    {
        public string Name { get; private set; }
        public GeoLocation Location { get; private set; }
        public int Sequence { get; private set; }

        public Stop(Guid? id, string name, GeoLocation location, int sequence = 0) : base(id)
        {
            SetName(name);
            Location = location ?? throw new ArgumentNullException(nameof(location));
            if (sequence < 0) throw new ArgumentOutOfRangeException(nameof(sequence));
            Sequence = sequence;
        }

        public Stop(string name, GeoLocation location, int sequence = 0) : this(null, name, location, sequence) { }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Stop name is required.", nameof(name));
            Name = name.Trim();
        }

        public void SetSequence(int sequence)
        {
            if (sequence < 0) throw new ArgumentOutOfRangeException(nameof(sequence));
            Sequence = sequence;
        }

        public void SetLocation(GeoLocation location)
        {
            Location = location ?? throw new ArgumentNullException(nameof(location));
        }
    }
}