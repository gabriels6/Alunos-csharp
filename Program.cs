using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {

            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;


            String opcaoUsuario;
            opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                Console.WriteLine();
                switch (opcaoUsuario)
                {
                    
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine("Informe a nota do aluno");

                        
                        if(Decimal.TryParse(Console.ReadLine(),out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }  

                        alunos[indiceAluno] = aluno;
                        indiceAluno++; 

                        break;
                    case "2":

                        Console.WriteLine("");
                        Console.WriteLine("Alunos");
                        Console.WriteLine("");

                        foreach(var a in alunos){
                            if(!string.IsNullOrEmpty(a.Nome)) 
                            Console.WriteLine($"Aluno: {a.Nome} \t Nota: {a.Nota}");  
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();

                        break;
                    case "3":
                        decimal NotaTotal = 0;
                        var QtdeAlunos = 0;

                        for(int i = 0;i < alunos.Length;i++){
                            if(!string.IsNullOrEmpty(alunos[i].Nome)){
                                NotaTotal += alunos[i].Nota;
                                QtdeAlunos++;
                            }

                        }

                        if(QtdeAlunos != 0){
                            var Media = NotaTotal/QtdeAlunos;
                            ConceitoEnum conceitoGeral = ConceitoEnum.E;
                            Console.WriteLine();


                            if(Media < 3)
                            {
                                conceitoGeral = ConceitoEnum.E;
                            }
                            else if(Media >= 3 && Media < 6)
                            {
                                conceitoGeral = ConceitoEnum.D;
                            }
                            else if(Media >= 5 && Media < 8)
                            {
                                conceitoGeral = ConceitoEnum.C;
                            }
                            else if(Media >= 8 && Media < 10)
                            {
                                conceitoGeral = ConceitoEnum.B;
                            }
                            else if(Media == 10)
                            {
                                conceitoGeral = ConceitoEnum.A;
                            }

                            Console.WriteLine($"Media total dos alunos: {Media.ToString("N1")} \t Conceito: {conceitoGeral}");

                            Console.WriteLine();
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadLine();
                        }else{
                            Console.WriteLine();
                            Console.WriteLine("Não há alunos cadastrados.");
                            Console.WriteLine();
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadLine();
                        }
                        

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }



        }

        private static string ObterOpcaoUsuario()
        {
            string opcaoUsuario;
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine("\t Escola XYZ");
            Console.WriteLine("================================");
            Console.WriteLine("Informe a opção desejada!");
            Console.WriteLine("1.\t inserir novo aluno");
            Console.WriteLine("2.\t listar alunos");
            Console.WriteLine("3. \t calcular média geral");
            Console.WriteLine("X. \t Sair do sistema");
            Console.WriteLine();

            opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
