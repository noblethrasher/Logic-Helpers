using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prelude
{
    static class LogicUtils
    {
        public static Implication Implies(this bool p, bool q)
        {
            return new Implication (() => p, () => q);
        }

        public static IEnumerable<T> Neigborhood<T>(this Func<T, T, double> dist, T x, T y)
        {
            throw new NotImplementedException ();
        }
    }

    struct Implication
    {
        public readonly Func<bool> consequent, antecendent;

        public Implication(Func<bool> Antecendent, Func<bool> Consequent)
            : this ()
        {
            this.consequent = Consequent;
            this.antecendent = Antecendent;
        }

        public static bool operator true(Implication p)
        {
            return !p.antecendent () || p.consequent ();
        }

        public static bool operator false(Implication p)
        {
            return !p.antecendent () || p.consequent ();
        }

        public static implicit operator bool(Implication p)
        {
            return !p.antecendent () || p.consequent ();
        }

        public Implication Converse
        {
            get
            {
                return new Implication (this.consequent, this.antecendent);
            }
        }

        public bool AndConversely()
        {
            return new DoubleImplication (this.antecendent, this.consequent);
        }
    }

    struct DoubleImplication
    {

        Implication p;

        public DoubleImplication(Func<bool> Consequent, Func<bool> Antecendent)
            : this ()
        {
            p = new Implication (Antecendent, Consequent);
        }

        public static bool operator true(DoubleImplication _iff)
        {
            return _iff.p && _iff.p.Converse;
        }

        public static bool operator false(DoubleImplication _iff)
        {
            return _iff.p && _iff.p.Converse;
        }

        public static implicit operator bool(DoubleImplication _iff)
        {
            return _iff.p && _iff.p.Converse;
        }
    }
}
