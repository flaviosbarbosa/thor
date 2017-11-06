package br.com.crusade.elroy.Model;

import java.io.Serializable;
import java.util.Date;
import java.util.Timer;

/**
 * Created by FlavioBarbosa on 20/09/17.
 */

public class Evento implements Serializable {

    private long id;
    private String titulo;
    private String descricao;
    private String data;
    private String local;
    private String horario;
    private String privado;

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getTitulo() {
        return titulo;
    }

    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    public String getDescricao() {
        return descricao;
    }

    public void setDescricao(String descricao) {
        this.descricao = descricao;
    }

    public String getData() {
        return data;
    }

    public void setData(String data) {
        this.data = data;
    }

    public String getLocal() {
        return local;
    }

    public void setLocal(String local) {
        this.local = local;
    }

    public String getHorario() {
        return horario;
    }

    public void setHorario(String horario) {
        this.horario = horario;
    }

    public String getPrivado() {
        return privado;
    }

    public void setPrivado(String privado) {
        this.privado = privado;
    }

    @Override
    public String toString() {
        return String.valueOf(id) + " - "  + titulo;
    }
}
