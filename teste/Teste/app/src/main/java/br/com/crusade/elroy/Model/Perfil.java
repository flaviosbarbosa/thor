package br.com.crusade.elroy.Model;

import java.io.Serializable;

/**
 * Created by FlavioBarbosa on 18/09/17.
 */

public class Perfil implements Serializable {

    private long id;
    private String nome;
    private String email;
    private String profissao;
    private String Genero;
    private String membro;
    private String permiteContato;
    private String permiteDivulgarProfissao;

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getProfissao() {
        return profissao;
    }

    public void setProfissao(String profissao) {
        this.profissao = profissao;
    }

    public String getGenero() {
        return Genero;
    }

    public void setGenero(String genero) {
        Genero = genero;
    }

    public String getMembro() {
        return membro;
    }

    public void setMembro(String membro) {
        this.membro = membro;
    }

    public String getPermiteContato() {
        return permiteContato;
    }

    public void setPermiteContato(String permiteContato) {
        this.permiteContato = permiteContato;
    }

    public String getPermiteDivulgarProfissao() {
        return permiteDivulgarProfissao;
    }

    public void setPermiteDivulgarProfissao(String permiteDivulgarProfissao) {
        this.permiteDivulgarProfissao = permiteDivulgarProfissao;
    }

    @Override
    public String toString() {
        return getId() + " - " + getNome();
    }
}
