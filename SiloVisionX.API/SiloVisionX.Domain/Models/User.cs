﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloVisionX.Domain.Models
{
    public class User
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public Roles Roles { get; set; }

    }
}
