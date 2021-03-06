﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M7
{
    public class LugarDireccion : Entidad
    {
        #region Atributos
        private string lugNombre;
        private string lugTipo;
        private int fk_lugId;

        private List<Entidad> address = new List<Entidad>();
        #endregion

        #region Constructor
        public LugarDireccion() { }

        public LugarDireccion(string lugNombre)
        {
            this.lugNombre = lugNombre;
        }

        public LugarDireccion(string lugNombre, string lugTipo, int fk_lugId)
        {
            this.lugNombre = lugNombre;
            this.lugTipo = lugTipo;
            this.fk_lugId = fk_lugId;
        }

        public LugarDireccion(string lugNombre, string lugTipo, int fk_lugId,
                              List<Entidad> address)
        {
            this.lugNombre = lugNombre;
            this.lugTipo = lugTipo;
            this.fk_lugId = fk_lugId;
            this.address = address;
        }

        public LugarDireccion(string lugNombre, string lugTipo)
        {
            this.lugNombre = lugNombre;
            this.lugTipo = lugTipo;
        }
        #endregion

        #region Get's Set's
 
        public string LugNombre
        {
            get
            {
                return this.lugNombre;
            }
            set
            {
                this.lugNombre = value;
            }
        }

        public string LugTipo
        {
            get
            {
                return this.lugTipo;
            }
            set
            {
                this.lugTipo = value;
            }
        }

        public int Fk_lugId
        {
            get
            {
                return this.fk_lugId;
            }
            set
            {
                this.fk_lugId = value;
            }
        }

        public List<Entidad> Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        #endregion
    }
}
