﻿namespace CasperAPI.Entidades
{
    public class Adscripcion
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Siglas { get; set; } = null!;     
        public int Titular { get; set; }

    }
}
