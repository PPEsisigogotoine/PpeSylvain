﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Business;
using CsvHelper;
using System.Data;
using System.Runtime.CompilerServices;
using CsvHelper.Configuration;
using CsvHelper.Expressions;
using CsvHelper.TypeConversion;
using System.IO;
using System.Globalization;

namespace ModelLayer.Data
{
    public class DaoVille
    {
        private Dbal mydbal;
        private DaoVille theDaoVille;

        public DaoVille(Dbal dbal, DaoVille DaoVille)
        {
            this.mydbal = dbal;
            this.theDaoVille = DaoVille;
        }

        public void Insert(Ville uneVille)
        {
            string query = "Ville (id, nom) VALUES ("
                + uneVille.Id + ",'"
                + uneVille.Nom.Replace("'", "''");
            this.mydbal.Insert(query);
        }

        public void Update(Ville uneVille)
        {
            string query = "Ville Set id = " + uneVille.Id
                + ", nom = '" + uneVille.Nom.Replace("'", "''")
                + "Where id = " + uneVille.Id;
            this.mydbal.Update(query);
        }

        public void Delete(Ville uneVille)
        {
            string query = "Ville Where id = " + uneVille.Id;
            this.mydbal.Delete(query);
        }

        public List<Ville> SelectAll()
        {
            List<Ville> listVille = new List<Ville>();
            DataTable myTable = this.mydbal.SelectAll("Ville");

            foreach (DataRow r in myTable.Rows)
            {
                listVille.Add(new Ville((int)r["id"], (string)r["nom"]));
            }
            return listVille;
        }

        public Ville SelectbyId(int id)
        {
            DataRow rowVille = this.mydbal.SelectById("ville", id);
            return new Ville((int)rowVille["id"],(string)rowVille["nom"]);
        }

       
    }
}
