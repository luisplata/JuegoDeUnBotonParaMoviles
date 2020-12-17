using System;
using System.Threading.Tasks;
using UnityEngine;

public class ManejadorDeMusica : IManejadorDeMusica
{
    private AudioClip intro;
    private AudioClip loop;
    private AudioClip ending;
    private AudioClip complet;
    private AudioSource fuente;

    public ManejadorDeMusica(AudioClip intro, AudioClip loop, AudioClip ending, AudioClip complet, AudioSource fuente)
    {
        this.intro = intro;
        this.loop = loop;
        this.ending = ending;
        this.complet = complet;
        this.fuente = fuente;
    }

    public void ComenzarLaMusicaLoopeada()
    {
        QuitarMusica();
        fuente.clip = intro;
        fuente.Play();
        EsperarQueLaIntroTermineParaComenzarElLoop(intro.length).WrapErrors();
    }

    private async Task EsperarQueLaIntroTermineParaComenzarElLoop(float length)
    {
        await Task.Delay(20);
        await Task.Delay(TimeSpan.FromSeconds(length));
        QuitarMusica();
        fuente.clip = loop;
        fuente.loop = true;
        fuente.Play();
    }

    public void ComenzarMusicaCompleta()
    {
        QuitarMusica();
        fuente.clip = complet;
        fuente.loop = true;
        fuente.Play();
    }

    public void QuitarMusica()
    {
        fuente.Stop();
        fuente.clip = null;
        fuente.loop = false;
    }
}