using System;
using PublicManagment.Domain.Common;

namespace PublicManagment.Domain.Entities
{
    public sealed class Driver : Entity
    {
        public string FullName { get; private set; }
        public string LicenseNumber { get; private set; }
        public bool Active { get; private set; }

        public Driver(Guid? id, string fullName, string licenseNumber, bool active = true) : base(id)
        {
            SetFullName(fullName);
            SetLicenseNumber(licenseNumber);
            Active = active;
        }

        public Driver(string fullName, string licenseNumber, bool active = true) : this(null, fullName, licenseNumber, active) { }

        public void SetFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("Full name is required", nameof(fullName));
            FullName = fullName.Trim();
        }

        public void SetLicenseNumber(string licenseNumber)
        {
            if (string.IsNullOrWhiteSpace(licenseNumber)) throw new ArgumentException("License number is required", nameof(licenseNumber));
            LicenseNumber = licenseNumber.Trim();
        }

        public void SetActive(bool active) => Active = active;
    }
}