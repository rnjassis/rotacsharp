using System;
using System.Collections.Generic;
using System.IO;

namespace RotasCSharp.Model
{
    /// <summary>
    /// Classe que carrega o arquivo
    /// </summary>
    class CarregarArquivo
    {
        private StreamReader sr;

        public CarregarArquivo()
        {
        }

        /// <summary>
        /// Carrega a configuração das estações e dos nós a partir do arquivo
        /// </summary>
        /// <returns>
        /// Dicionário com as estações
        /// </returns>
        public Dictionary<string, Estacao> LoadProperties()
        {
            Dictionary<string, Estacao> estacoes = new Dictionary<string, Estacao>();
            estacoes.Add("A", new Estacao("A"));
            estacoes.Add("B", new Estacao("B"));
            estacoes.Add("C", new Estacao("C"));
            estacoes.Add("D", new Estacao("D"));
            estacoes.Add("E", new Estacao("E"));

            try
            {
                sr = new StreamReader("inputs.txt");
                String line;
                while (!(line = sr.ReadLine()).Equals("$session-config-start$")) ;

                while (!(line = sr.ReadLine()).Equals("$session-config-stop$"))
                {
                    if (line.StartsWith("#"))
                    {
                        continue;
                    }

                    string[] pontos = line.Split("-");
                    estacoes[pontos[0]].estAdj.Add(estacoes[pontos[1]], int.Parse(pontos[2]));      
                 }
                
            }
            catch (FileNotFoundException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
            }

            return estacoes;
        }

        /// <summary>
        /// Carrega as perguntas do arquivo, cada uma possui um código para diferenciar
        /// </summary>
        /// <returns>
        /// String com as respostas
        /// </returns>
        public List<string> loadQuestions()
        {
            List<string> questions = new List<string>();
            try
            {
                sr = new StreamReader("inputs.txt");
                string line;
                while (!(line = sr.ReadLine()).Equals("$session-questions-start$"));

                while (!(line = sr.ReadLine()).Equals("$session-questions-stop$"))
                {
                    if (line.StartsWith("#"))
                    {
                        continue;
                    }
                    questions.Add(line);
                }
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
            }

            return questions;
        }
    }
}
