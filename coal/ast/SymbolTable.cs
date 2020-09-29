﻿using System;
using System.Collections.Generic;

using Microsoft.FSharp.Core;

namespace CoalLang {
    public class SymbolTable {
        public Ast.Prog m_prog;
        public List<Dictionary<String, Ast.Stmt.Vardef>> m_symbolTable;
        public SymbolTable (Ast.Prog prog) {
            // Create the symbol table and push a scope onto it
            this.m_symbolTable = new List<Dictionary<string, Ast.Stmt.Vardef>>();
            this.PushNewScope();
            this.m_prog = prog;
        }

        // Adds a new Key Value Pair to the current scope
        public bool Insert(String name, Ast.Stmt.Vardef vardef) {
            try {
                KeyValuePair<String, Ast.Stmt.Vardef> ins = new KeyValuePair<String, Ast.Stmt.Vardef>(name, vardef);
                this.m_symbolTable[m_symbolTable.Count - 1].Add(name, vardef);
                return true;
            } catch (System.ArgumentException) {
                return false;
            }
        }
        
        // Pushes a new scope onto the symbol table
        public void PushNewScope () {
            this.m_symbolTable.Add(new Dictionary<string, Ast.Stmt.Vardef>());
        }

        public void PopScope () {
            this.m_symbolTable.RemoveAt(this.m_symbolTable.Count - 1);
        }
    }
}