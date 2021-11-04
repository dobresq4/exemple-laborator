﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucrarea2_DobrescuAndrei.Domain
{
    public record PayShoppingCartCommand
    {
        public PayShoppingCartCommand(IReadOnlyCollection<EmptyShoppingCart> inputShoppingCarts)
        {
            InputShoppingCarts = inputShoppingCarts;
        }

        public IReadOnlyCollection<EmptyShoppingCart> InputShoppingCarts { get; }
    }
}