# Backtracking_Domino
Implementação de um programa em C# que resolve o jogo de Dominó usando a técnica de Backtracking.

Este projeto foi criado a partir de um trabalho da disciplina de Complexidade e Otimização do curso de Ciência da Computação da PUCRS.

As peças podem ser geradas utilizando o programa [Dominoes Pieces Generator](https://github.com/brbmendes/Dominoes_Pieces_Generator "Dominoes Pieces Generator").

> Backtracking: Técnica de que utiliza força bruta para achar a solução de um problema. A busca utilizando backtracking vai percorrer uma árvore fazendo busca em profundidade (percorrida sistematicamente de cima para baixo e da esquerda para direita). Em caso de falha, ou encontrar um nodo folha na árvore, o mecanismo de backtracking retorna o caminho percorrido visando encontrar soluções alternativas ao problema, até encontrar a solução (achou o que era procurado) ou confirmar que não existe solução para o problema (não achou).

## Manual de utilização: ##

###  Entrada do programa ###
>      Arquivos de texto com a extensão .txt.

>      Na primeira linha, é informada quantas peças serão utilizadas no jogo.

>      As peças contém os dois números separados por um espaço simples.   

>      Em geral, as peças vão de 0 até 10, mas pode ter valores maiores que 10.
      
>      Ex: game_1.txt
      
>      5
>      1 3
>      4 8
>      4 1
>      5 4
>      5 8
  
###  Utilização do programa ###
>    Dentro do repositório, no diretório "Backtracking_Domino-master\Backtracking_Domino master\Backtracking_Domino\bin\Debug\" contém um arquivo chamado "Backtracking_Domino.cheating". 

>    Renomeie o arquivo para "Backtracking_Domino.exe"

>    Execute o arquivo, informando por parâmetro um ou mais arquivos de entrada conforme o exemplo abaixo.
    
    Ex: Backtracking_Domino-master\Backtracking_Domino-master\Backtracking_Domino\bin\Debug\Backtracking_Domino.exe game_1.txt game_2.txt game_3.txt game_4.txt game_5.txt game_6.txt
    
    OBS: Pode ser informado um ou mais arquivos de entrada.
    
    
###  Saída do programa: ###
>    Backtracking_Domino\Backtracking_Domino\bin\Debug\Backtracking_Domino.exe game_1.txt game_2.txt
  
> ###########################################################################
>
>
>Reading File ==> game_1.txt....
>
>Solution has found. The solution is:
>
>
>[ 3 : 1 ] [ 1 : 4 ] [ 4 : 8 ] [ 8 : 5 ] [ 5 : 4 ]
>
>Tempo de execução:       00:00:00.0043023
>###########################################################################
>###########################################################################
>
>
>Reading File ==> game_2.txt....
>
>No solution has found. The pieces were:
>
>
>[ 9 : 1 ] [ 6 : 7 ] [ 2 : 3 ] [ 5 : 1 ] [ 4 : 8 ] [ 7 : 9 ]
>
>Tempo de execução:       00:00:00.0046311
>###########################################################################
