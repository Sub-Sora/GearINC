interface IRessourceHolder
{
    /// <summary>
    /// Permet de r�cup�rer une ressource
    /// </summary>
    /// <param name="ressource"></param>
    void GetRessource(Ressource ressource);

    /// <summary>
    /// Permet de perdre une ressource
    /// </summary>
    void LoseRessource();
}