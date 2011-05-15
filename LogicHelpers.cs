﻿using System;
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

        public static bool _eval(Implication p)
        {
            return !p. antecedent () || p.consequent ();
        }


        public static bool operator true(Implication p)
        {
            return _eval(p);
        }

        public static bool operator false(Implication p)
        {
            return _eval(p);
        }

        public static implicit operator bool(Implication p)
        {
            return _eval(p);
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

        public static bool _eval(DoubleImplication _iff)
        {
            return _iff.p && _iff.p.Converse;
        }

        public static bool operator true(DoubleImplication _iff)
        {
            return _eval(_iff);
        }

        public static bool operator false(DoubleImplication _iff)
        {
            return _eval(_iff);
        }

        public static implicit operator bool(DoubleImplication _iff)
        {
            return _eval(_iff);
        }
    }
}
