using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Mod.views
{
    public class validadores
    {
        public void AtualizarCampoComDataPadrao(MaskedTextBox campoTexto, out DateTime data) //atualiza campo data no Salvar();
        {
            string entrada = campoTexto.Text;
            DateTime dataPadrao = new DateTime(1800, 1, 1);

            if (DateTime.TryParse(entrada, out data))
            {
                // Se a conversão for bem-sucedida, é utilizada a data convertida
                campoTexto.Text = data.ToString("dd/MM/yyyy");
            }
            else
            {
                // Se a conversão falhar, é definida uma data padrão
                campoTexto.Text = dataPadrao.ToString("dd/MM/yyyy");
                data = dataPadrao;
            }
        }

        public void AtualizarCampoData(DateTime data, MaskedTextBox campoTexto) //atualiza campo data no Carrega();
        {
            DateTime dataPadrao = new DateTime(1800, 1, 1);
            if (data == dataPadrao)
            {
                campoTexto.Clear(); // Deixa o campo vazio
            }
            else
            {
                campoTexto.Text = data.ToString();
            }
        }

        public static bool VerificaLetras(string texto)
        {
            //se o campo estiver vazio, considera-se válido
            if (string.IsNullOrWhiteSpace(texto))
                return true;

            //verificar se a string contém somente letras, espaços, acentos e ç
            Regex regex = new Regex(@"^[a-zA-ZÀ-ü\sçÇ]+$");

            return regex.IsMatch(texto);
        }

        public static bool VerificaLetrasSemEspaco(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return true;

            //verificar se a string contém somente letras (sem espaços)
            Regex regex = new Regex("^[a-zA-Z]+$");

            return regex.IsMatch(texto);
        }

        public static bool VerificaNumeros(string texto)
        {
            //se o campo estiver vazio, considera-se válido
            if (string.IsNullOrWhiteSpace(texto))
                return true;

            //verificar se a string contém somente números (sem espaços entre eles)
            Regex regex = new Regex("^[0-9]+$");

            return regex.IsMatch(texto);
        }

        public static bool CampoObrigatorio(string texto)
        {
            //verifica se o texto está vazio ou contém apenas espaços em branco
            return !string.IsNullOrWhiteSpace(texto);
        }

        public static bool ValidaCNPJ(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
            {
                return true;
            }
            else
            {
                // Remove caracteres não numéricos
                cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

                // Verifica se a string tem 14 caracteres (tamanho de um CNPJ)
                if (cnpj.Length != 14)
                    return false;

                // Calcula o primeiro dígito verificador
                int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma = 0;
                for (int i = 0; i < 12; i++)
                {
                    soma += int.Parse(cnpj[i].ToString()) * multiplicadores1[i];
                }
                int resto = soma % 11;
                int dv1 = resto < 2 ? 0 : 11 - resto;

                // Calcula o segundo dígito verificador
                int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                soma = 0;
                for (int i = 0; i < 13; i++)
                {
                    soma += int.Parse(cnpj[i].ToString()) * multiplicadores2[i];
                }
                resto = soma % 11;
                int dv2 = resto < 2 ? 0 : 11 - resto;

                // Verifica se os dígitos verificadores calculados são iguais aos informados
                return dv1 == int.Parse(cnpj[12].ToString()) && dv2 == int.Parse(cnpj[13].ToString());
            }
        }

        public static bool ValidaCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                return true;
            }
            else
            {
                // Remove caracteres não numéricos
                cpf = cpf.Replace(".", "").Replace("-", "");

                // Verifica se a string tem 11 caracteres (tamanho de um CPF)
                if (cpf.Length != 11)
                    return false;

                // Verifica se todos os dígitos são iguais
                bool todosIguais = true;
                for (int i = 1; i < cpf.Length; i++)
                {
                    if (cpf[i] != cpf[0])
                    {
                        todosIguais = false;
                        break;
                    }
                }
                if (todosIguais)
                    return false;

                // Calcula o primeiro dígito verificador
                int soma = 0;
                for (int i = 0; i < 9; i++)
                {
                    soma += int.Parse(cpf[i].ToString()) * (10 - i);
                }
                int resto = soma % 11;
                int dv1 = resto < 2 ? 0 : 11 - resto;

                // Calcula o segundo dígito verificador
                soma = 0;
                for (int i = 0; i < 10; i++)
                {
                    soma += int.Parse(cpf[i].ToString()) * (11 - i);
                }
                resto = soma % 11;
                int dv2 = resto < 2 ? 0 : 11 - resto;

                // Verifica se os dígitos verificadores calculados são iguais aos informados
                return dv1 == int.Parse(cpf[9].ToString()) && dv2 == int.Parse(cpf[10].ToString());
            }
        }

        public static bool ValidaEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return true;
            else
            {
                string padrao = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                Regex regex = new Regex(padrao);
                return regex.IsMatch(email);
            }
        }

        public static bool ValidaPis(string pis)
        {
            if (string.IsNullOrWhiteSpace(pis))
            {
                return true;
            }
            else
            {
                int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                if (pis.Trim().Length != 11)
                    return false;
                pis = pis.Trim();
                pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(pis[i].ToString()) * multiplicador[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                return pis.EndsWith(resto.ToString());
            }




        }
    }
}
