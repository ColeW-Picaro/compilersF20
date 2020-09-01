﻿module Program
open FSharp.Text.Lexing
open Lexer

let simpleJson = @"{
              ""title"": ""Cities"",
              ""cities"": [
                { ""name"": ""Chicago"",  ""zips"": [60601,60600] },
                { ""name"": ""New York"", ""zips"": [10001] } 
              ]
            }"

let program = @"
  
"            

let printToken (t : Lexer.token) = match t with
  | INT_LIT e -> printf "int(%d) " e
  | FLOAT_LIT e -> printf "float(%f) " e
  | STRING_LIT e -> printf "'%s' " e
  | BOOL_LIT e -> printf "%s " (if e then "true" else "false")
  | IDENTIFIER e -> printf "id(%s) " e 
  | NIL -> printf "nil " 
  | STRING -> printf "string "
  | INT -> printf "int "
  | FLOAT -> printf "float "
  | BOOL -> printf "bool "
  | LET -> printf "let "
  | DO -> printf "do "
  | END  -> printf "end "
  | IF -> printf "if "
  | FOR -> printf "for "
  | WHILE -> printf "while "
  | UNTIL -> printf "until "
  | UNLESS -> printf "unless "
  | CLASS -> printf "class "
  | SUPER -> printf "super "
  | THIS -> printf "this "
  | BANG_EQUAL -> printf "!= "
  | GREATER_EQUAL -> printf ">= "
  | LESS_EQUAL  -> printf "<= "
  | EQUAL_EQUAL -> printf "== "
  | AND -> printf "&& "
  | OR -> printf "|| "
  | DOT_DOT -> printf ".. "
  | BANG -> printf "! "
  | GREATER -> printf "> "
  | LESS -> printf "< "
  | EQUAL -> printf "= "
  | LEFT_PAREN -> printf "("
  | RIGHT_PAREN -> printf ") "
  | COLON -> printf ": "
  | COMMA -> printf ", "
  | DOT -> printf ". "
  | SLASH -> printf "/ "
  | STAR -> printf "* "
  | MINUS -> printf "- "
  | PLUS -> printf "+ "
  | SEMICOLON -> printf "; "
  | EOF -> printf "EOF"

let parse program = 
    let lexbuf = LexBuffer<char>.FromString program in
    let rec next lexeme = 
      printToken lexeme;
      match lexeme with
        | EOF -> 0
        | _ -> 1 + next (Lexer.read lexbuf)
    next (Lexer.read lexbuf)
      

[<EntryPoint>]
let main argv =
    match parse program with    
    | _ -> 0
