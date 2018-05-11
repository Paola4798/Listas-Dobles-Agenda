using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasEnlazadasDoblesAgenda
{
    class Contactos
    {
        Persona ultimo, primero, encontrado, temp, anterior;

        public Contactos()
        {
            primero = null;
        }

        public void agregar(Persona nuevaP)
        {
            if (primero == null)
            {
                primero = nuevaP;
                ultimo = nuevaP;
            }
            else
            {
                if (primero.siguiente == null)
                    if (primero.codigo > nuevaP.codigo)
                    {
                        nuevaP.siguiente = primero;
                        ultimo = primero;
                        primero = nuevaP;
                        primero.siguiente = ultimo;
                        ultimo.anteriror = primero;
                    }
                    else
                    {
                        primero.siguiente = nuevaP;
                        ultimo = nuevaP;
                        ultimo.anteriror = primero;
                    }
                else
                {
                    if (primero.codigo > nuevaP.codigo)
                    {
                        nuevaP.siguiente = primero;
                        primero.anteriror = nuevaP;
                        primero = nuevaP;
                    }
                    else if (ultimo.codigo < nuevaP.codigo)
                    {
                        ultimo.siguiente = nuevaP;
                        nuevaP.anteriror = ultimo;
                        ultimo = nuevaP;
                    }
                    else
                    {
                        temp = primero;

                        while (temp.siguiente.codigo < nuevaP.codigo && temp.siguiente != ultimo)
                        {
                            temp = temp.siguiente;
                        }

                        nuevaP.siguiente = temp.siguiente;
                        temp.siguiente.anteriror = nuevaP;
                        temp.siguiente = nuevaP;
                        nuevaP.anteriror = temp;
                    }
                }
            }
        }
        public Persona buscar(int codigoP)
        {
            temp = primero;
            encontrado = null;

            while (encontrado == null && temp != null)
                if (temp.codigo == codigoP)
                    encontrado = temp;
                else
                {
                    anterior = temp;
                    temp = temp.siguiente;
                }

            return encontrado;
        }
        public bool eliminar(int codigoP)
        {
            if (buscar(codigoP) != null)
            {
                if (encontrado == primero)
                    primero = primero.siguiente;
                else
                    anterior.siguiente = encontrado.siguiente;

                return true;
            }
            else
                return false;
        }
        public string mostrar()
        {
            string vPersona = "";
            temp = primero;

            while (temp != null)
            {
                vPersona += temp.ToString() + Environment.NewLine;
                temp = temp.siguiente;
            }

            return vPersona;
        }
        public bool eliminarPrimero()
        {
            if (primero == null)
                return false;
            else
            {
                primero = primero.siguiente;
               
                return true;
            }
        }

        public bool eliminarUltimo()
        {
            if (ultimo == null)
                return false;
            else
            {
                ultimo = ultimo.anteriror;
                ultimo.siguiente = null;
              
                return true;
            }
        }
        public string inverso()
        {
            return mostrarInverso(primero);
        }
        private string mostrarInverso(Persona temp)
        {
            string vPersona = "";

            if (temp.siguiente != null)
                vPersona = mostrarInverso(temp.siguiente);
            vPersona += temp.ToString() + Environment.NewLine;
            return vPersona;
        }
    }
}
