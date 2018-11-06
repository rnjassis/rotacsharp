using System;
using System.Collections.Generic;
using System.IO;

namespace RotasCSharp.Model
{
    class LoadFile
    {
        private StreamReader sr;

        public LoadFile()
        {
        }

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
                    string[] pontos = line.Split("-");
                    if (!estacoes[pontos[0]].destinos.ContainsKey(pontos[1]))
                    {
                        estacoes[pontos[0]].destinos.Add(pontos[1], new Destino(estacoes[pontos[1]], int.Parse(pontos[2])));
                    }      
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

            return estacoes;
        }

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
                    if (line.Contains("#"))
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
