using System;
using System.Collections.Generic;
using System.Linq;
using PublicManagment.Domain.Common;

namespace PublicManagment.Domain.Entities
{
    public sealed class Line : AggregateRoot
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        private readonly List<Stop> _stops = new();
        public IReadOnlyList<Stop> Stops => _stops.AsReadOnly();

        public Line(Guid? id, string code, string name) : base(id)
        {
            SetCode(code);
            SetName(name);
        }

        public Line(string code, string name) : this(null, code, name) { }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Line name is required.", nameof(name));
            Name = name.Trim();
        }

        public void SetCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Line code is required.", nameof(code));
            Code = code.Trim();
        }

        public void AddStop(Stop stop, int? position = null)
        {
            if (stop == null) throw new ArgumentNullException(nameof(stop));
            if (position == null || position < 0 || position > _stops.Count)
            {
                _stops.Add(stop);
            }
            else
            {
                _stops.Insert(position.Value, stop);
            }
            ReindexStops();
        }

        public bool RemoveStop(Guid stopId)
        {
            var s = _stops.FirstOrDefault(x => x.Id == stopId);
            if (s == null) return false;
            _stops.Remove(s);
            ReindexStops();
            return true;
        }

        private void ReindexStops()
        {
            for (int i = 0; i < _stops.Count; i++) _stops[i].SetSequence(i + 1);
        }
    }
}