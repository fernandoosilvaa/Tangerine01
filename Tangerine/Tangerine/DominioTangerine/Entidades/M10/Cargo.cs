﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M10
{
    public class Cargo : Entidad
    {
        #region Atributos
        private string nombre;
        private string descripcion;
        private DateTime fechaContratacion;
        private DateTime fechaFinContrato;
        private string modalidad;
        private double sueldo;

        private string fechaIni;
        private string fechaFin;

        private int fk_car_id;
        private int fk_emp_num_ficha;
        private int car_id;

        private List<Entidad> listEmployees;
        private string empCargo;
        private string empCargoDescripcion;
        private string empContratacion;
        private string empModalidad;
        private double empSalario;
        #endregion

        #region constructores
        public Cargo() { }


        public Cargo(string cargo, double salary, string dateIni, string dateFin)
        {
            this.nombre = cargo;
            this.fechaIni = dateIni;
            this.fechaFin = dateFin;
            this.sueldo = salary;
        }

        public Cargo(string nombre, string descripcion, DateTime fecha)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fechaContratacion = fecha;
            
        }

        public Cargo(int carId, string nombre, string descripcion)
        {
            this.car_id = carId;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
        public Cargo(int fk_car_id, int fk_emp_num_ficha, DateTime dateIni, DateTime dateFin,
                     string mode, double salary)
        {
            this.fk_car_id = fk_car_id;
            this.fk_emp_num_ficha = fk_emp_num_ficha;
            this.fechaContratacion = dateIni;
            this.fechaFinContrato = dateFin;
            this.modalidad = mode;
            this.sueldo = salary;
        }

        public Cargo(int carId, string nombre, string descripcion, int fk_car_id,
                     int fk_emp_num_ficha, DateTime dateIni, DateTime dateFin,
                     string mode, double salary)
        {
            this.car_id = carId;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fk_car_id = fk_car_id;
            this.fk_emp_num_ficha = fk_emp_num_ficha;
            this.fechaContratacion = dateIni;
            this.fechaFinContrato = dateFin;
            this.modalidad = mode;
            this.sueldo = salary;
        }

        public Cargo(int carId, string nombre, string descripcion, int fk_car_id,
                     int fk_emp_num_ficha, DateTime dateIni,
                     string mode, double salary)
        {
            this.car_id = carId;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fk_car_id = fk_car_id;
            this.fk_emp_num_ficha = fk_emp_num_ficha;
            this.fechaContratacion = dateIni;
            this.modalidad = mode;
            this.sueldo = salary;
        }

        /*cargo de creacion con empleado*/
        public Cargo(string name, string summaryJob, DateTime dateJob, string jobMode, Double Salary)
        {
            this.nombre = name;
            this.descripcion = summaryJob;
            this.fechaContratacion = dateJob;
            this.modalidad = jobMode;
            this.sueldo = Salary;
        }

        public Cargo(string empCargo, string empCargoDescripcion, string empContratacion, string empModalidad, double empSalario)
        {
            // TODO: Complete member initialization
            this.empCargo = empCargo;
            this.empCargoDescripcion = empCargoDescripcion;
            this.empContratacion = empContratacion;
            this.empModalidad = empModalidad;
            this.empSalario = empSalario;
        }
        #endregion

        # region Get's Set's
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        public DateTime FechaContratacion
        {
            get
            {
                return this.fechaContratacion;
            }
            set
            {
                this.fechaContratacion = value;
            }
        }

        public DateTime FechaFinContrato
        {
            get
            {
                return this.fechaFinContrato;
            }
            set
            {
                this.fechaFinContrato = value;
            }
        }

        public string Modalidad
        {
            get
            {
                return this.modalidad;
            }
            set
            {
                this.modalidad = value;
            }
        }

        public double Sueldo
        {
            get
            {
                return this.sueldo;
            }
            set
            {
                this.sueldo = value;
            }
        }

        public int Fk_car_id
        {
            get
            {
                return this.fk_car_id;
            }
            set
            {
                this.fk_car_id = value;
            }
        }

        public int Fk_emp_num_ficha
        {
            get
            {
                return this.fk_emp_num_ficha;
            }
            set
            {
                this.fk_emp_num_ficha = value;
            }
        }

        public int Car_id
        {
            get
            {
                return this.car_id;
            }
            set
            {
                this.car_id = value;
            }
        }

        public string FechaIni
        {
            get
            {
                return this.fechaIni;
            }
            set
            {
                this.fechaIni = value;
            }
        }

        public string FechaFin
        {
            get
            {
                return this.fechaFin;
            }
            set
            {
                this.fechaFin = value;
            }
        }

        public List<Entidad> ListEmployees
        {
            get
            {
                return this.listEmployees;
            }
            set
            {
                this.listEmployees = value;
            }
        }
        #endregion
    }
}
