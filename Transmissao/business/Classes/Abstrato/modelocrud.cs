﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace business.Classes.Abstrato
{
    public abstract class modelocrud
    {

        public modelocrud()
        {
          //  this.bd = new BDcomum();
          //  this.banco = new CamDB();
        }

        [Key]
        public int Id { get; set; }

        private string insert_padrao;
        private string update_padrao;
        private string delete_padrao;
        private string select_padrao;

        [NotMapped]
        public string Insert_padrao { get => insert_padrao; set => insert_padrao = value; }
        [NotMapped]
        public string Update_padrao { get => update_padrao; set => update_padrao = value; }
        [NotMapped]
        public string Delete_padrao { get => delete_padrao; set => delete_padrao = value; }
        [NotMapped]
        public string Select_padrao { get => select_padrao; set => select_padrao = value; }

       // public BDcomum bd;
       // public CamDB banco;

        public abstract string salvar();
        public abstract string alterar(int id);
        public abstract string excluir(int id);
        public abstract List<modelocrud> recuperar(int? id);

        public bool retornoDados(SqlDataReader dr, string pesquisa)
        {
            try
            {
                int valor = int.Parse(Convert.ToString(dr[pesquisa]));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}