using System;
using PublicManagment.Domain.Common;
using PublicManagment.Domain.Enums;

namespace PublicManagment.Domain.Entities
{
    public sealed class Vehicle : Entity
    {
        public string Registration { get; private set; }
        public VehicleType Type { get; private set; }
        public string Model { get; private set; }

        public Vehicle(Guid? id, string registration, VehicleType type, string model = "") : base(id)
        {
            SetRegistration(registration);
            Type = type;
            Model = model ?? string.Empty;
        }

        public Vehicle(string registration, VehicleType type, string model = "") : this(null, registration, type, model) { }

        public void SetRegistration(string registration)
        {
            if (string.IsNullOrWhiteSpace(registration)) throw new ArgumentException("Registration required", nameof(registration));
            Registration = registration.Trim();
        }

        public void SetModel(string model)
        {
            Model = model ?? string.Empty;
        }

        public void SetType(VehicleType type)
        {
            Type = type;
        }
    }
}