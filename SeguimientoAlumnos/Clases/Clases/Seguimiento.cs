﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Seguimiento  //agregue la clase seguimiento
    {
        public string Causa { get; set; }   //agregue string causa

        public int ID { get; set; } //agregue int ID

        public string Mensaje { get; set; } //agregue string Mensaje

        public DateTime Fecha { get; set; }

    }
}
