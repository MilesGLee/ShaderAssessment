using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CookingBehaviour : MonoBehaviour
{
    //Variables used for cooking
    [SerializeField] private GameObject _puffParticle; 
    [SerializeField] private GameObject _infoObject;
    [SerializeField] private GameObject _buttonsObject;
    [SerializeField] private GameObject _soupObject;
    [SerializeField] private GameObject _dissolveBoard;
    [SerializeField] private GameObject _powerupBoard;
    [SerializeField] private GameObject _dotBoard;
    //Variables for the dissolve shader
    [SerializeField] private TMP_Text _modelText;
    [SerializeField] private TMP_Text _textureText;
    [SerializeField] private TMP_Text _colorText;
    [SerializeField] private TMP_Text _widthText;
    [SerializeField] private TMP_Text _noiseText;
    //Variables for the power up shader
    [SerializeField] private TMP_Text _powerModelText;
    [SerializeField] private TMP_Text _powerTextureText;
    [SerializeField] private TMP_Text _powerColorText;
    [SerializeField] private TMP_Text _powerSpeedText;
    [SerializeField] private TMP_Text _powerWidthText;
    [SerializeField] private TMP_Text _powerHeightText;
    //Variables for the dot matrix shader
    [SerializeField] private TMP_Text _dotModelText;
    [SerializeField] private TMP_Text _dotTextureText;
    [SerializeField] private TMP_Text _dotColorText;
    [SerializeField] private TMP_Text _dotSizeText;
    [SerializeField] private TMP_Text _dotSpaceText;

    //Referenced base objects
    [SerializeField] private GameObject _cubeBase;
    [SerializeField] private GameObject _sphereBase;
    [SerializeField] private GameObject _cylinderBase;
    [SerializeField] private GameObject _capsuleBase;
    //Referenced base textures
    [SerializeField] private Texture _tileBase;
    [SerializeField] private Texture _hexBase;
    [SerializeField] private Texture _smileBase;
    //Referenced base shaders
    [SerializeField] private Shader _dissolveBase;
    [SerializeField] private Shader _powerupBase;
    [SerializeField] private Shader _dotBase;

    //Enum for what mode the cooking pot is in
    private enum CookingMode 
    {
        EMPTY,
        DISSOLVE,
        POWERUP,
        DOTMATRIX
    }
    private CookingMode _cookingMode;
    private bool _cookTrigger;
    private string _baseModel;
    private string _baseTexture;
    private Color _baseColor;
    //The variables for manipulating the shaders variables
    private float _edgeWidth, _noisePower, _powerWidth, _powerHeight, _powerSpeed, _dotSize, _dotSpace;


    private void Start()
    {
        //Default cooking mode
        _cookingMode = CookingMode.EMPTY;
    }

    private void Update()
    {
        //If the pot is empty
        if (_cookingMode == CookingMode.EMPTY) 
        {
            _infoObject.SetActive(true);
            _buttonsObject.SetActive(false);
            _dissolveBoard.SetActive(false);
            _powerupBoard.SetActive(false);
            _dotBoard.SetActive(false);
            _soupObject.SetActive(false);
            _cookTrigger = false;
        }
        //If cooking a dissolve shader
        if (_cookingMode == CookingMode.DISSOLVE)
        {
            _infoObject.SetActive(false);
            _buttonsObject.SetActive(true);
            _dissolveBoard.SetActive(true);
            _powerupBoard.SetActive(false);
            _dotBoard.SetActive(false);
            _soupObject.SetActive(true);
            _cookTrigger = true;
            _modelText.text = "Model: " + _baseModel;
            _textureText.text = "Texture: " + _baseTexture;
            _widthText.text = "Edge Width: " + _edgeWidth;
            _noiseText.text = "Noise Scale: " + _noisePower;
        }
        //If cooking a power up shader
        if (_cookingMode == CookingMode.POWERUP)
        {
            _infoObject.SetActive(false);
            _buttonsObject.SetActive(true);
            _dissolveBoard.SetActive(false);
            _powerupBoard.SetActive(true);
            _dotBoard.SetActive(false);
            _soupObject.SetActive(true);
            _cookTrigger = true;
            _powerModelText.text = "Model: " + _baseModel;
            _powerTextureText.text = "Texture: " + _baseTexture;
            _powerSpeedText.text = "Speed: " + _powerSpeed;
            _powerWidthText.text = "Width: " + _powerWidth;
            _powerHeightText.text = "Height: " + _powerHeight;
        }
        //If cooking a dot matrix shader
        if (_cookingMode == CookingMode.DOTMATRIX)
        {
            _infoObject.SetActive(false);
            _buttonsObject.SetActive(true);
            _dissolveBoard.SetActive(false);
            _powerupBoard.SetActive(false);
            _dotBoard.SetActive(true);
            _soupObject.SetActive(true);
            _cookTrigger = true;
            _dotModelText.text = "Model: " + _baseModel;
            _dotTextureText.text = "Texture: " + _baseTexture;
            _dotSizeText.text = "Size: " + _dotSize;
            _dotSpaceText.text = "Space: " + _dotSpace;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the pot is empty
        if (_cookingMode == CookingMode.EMPTY) 
        {
            if (other.tag == "DissolveShader") 
            {
                ColorWhite();
                _baseModel = "";
                _baseTexture = "";
                _edgeWidth = 0.01f;
                _noisePower = 30.0f;
                Destroy(other.gameObject);
                Instantiate(_puffParticle, transform.position, Quaternion.identity);
                _cookingMode = CookingMode.DISSOLVE;
            }
            if (other.tag == "PowerupShader")
            {
                ColorWhite();
                _baseModel = "";
                _baseTexture = "";
                _powerSpeed = 1;
                _powerWidth = 1;
                _powerHeight = 1;
                Destroy(other.gameObject);
                Instantiate(_puffParticle, transform.position, Quaternion.identity);
                _cookingMode = CookingMode.POWERUP;
            }
            if (other.tag == "DotMatrixShader")
            {
                ColorWhite();
                _baseModel = "";
                _baseTexture = "";
                _dotSize = 1;
                _dotSpace = 1;
                Destroy(other.gameObject);
                Instantiate(_puffParticle, transform.position, Quaternion.identity);
                _cookingMode = CookingMode.DOTMATRIX;
            }
        }
        //If the pot is not empty
        if (_cookingMode != CookingMode.EMPTY) 
        {
            if (other.tag == "Cube" || other.tag == "Sphere" || other.tag == "Cylinder" || other.tag == "Capsule") 
            {
                Destroy(other.gameObject);
                Instantiate(_puffParticle, transform.position, Quaternion.identity);
                _baseModel = other.tag;
            }
            if (other.tag == "Tile" || other.tag == "Smile" || other.tag == "Hexagon") 
            {
                Destroy(other.gameObject);
                Instantiate(_puffParticle, transform.position, Quaternion.identity);
                _baseTexture = other.tag;
            }
        }
    }

    /// <summary>
    /// Reset the pot to empty state
    /// </summary>
    public void ResetRecipe() 
    {
        _cookingMode = CookingMode.EMPTY;
    }

    /// <summary>
    /// Spawn a new game object based on the ingredients and chosen variables
    /// </summary>
    public void CookObject() 
    {
        //Spawn dissolve object
        if (_cookingMode == CookingMode.DISSOLVE) 
        {
            _cookingMode = CookingMode.EMPTY;

            Material spawnMat = new Material(_dissolveBase);
            if (_baseTexture == "Tile")
                spawnMat.SetTexture("_BaseTexture", _tileBase);
            if (_baseTexture == "Hexagon")
                spawnMat.SetTexture("_BaseTexture", _hexBase);
            if (_baseTexture == "Smile")
                spawnMat.SetTexture("_BaseTexture", _smileBase);
            spawnMat.SetColor("_BaseColor", _baseColor);
            spawnMat.SetFloat("_EdgeWidth", _edgeWidth);
            spawnMat.SetFloat("_NoiseScale", _noisePower);

            if (_baseModel == "Cube")
            {
                GameObject spawn = Instantiate(_cubeBase, transform.position, Quaternion.identity);
                spawn.tag = "Untagged";
                spawn.GetComponent<MeshRenderer>().material = spawnMat;
            }

            if (_baseModel == "Sphere")
            {
                GameObject spawn = Instantiate(_sphereBase, transform.position, Quaternion.identity);
                spawn.tag = "Untagged";
                spawn.GetComponent<MeshRenderer>().material = spawnMat;
            }

            if (_baseModel == "Cylinder")
            {
                GameObject spawn = Instantiate(_cylinderBase, transform.position, Quaternion.identity);
                spawn.tag = "Untagged";
                spawn.GetComponent<MeshRenderer>().material = spawnMat;
            }

            if (_baseModel == "Capsule")
            {
                GameObject spawn = Instantiate(_capsuleBase, transform.position, Quaternion.identity);
                spawn.tag = "Untagged";
                spawn.GetComponent<MeshRenderer>().material = spawnMat;
            }

            Instantiate(_puffParticle, transform.position, Quaternion.identity);
        }

        //Spawn Power up object
        if (_cookingMode == CookingMode.POWERUP)
        {
            _cookingMode = CookingMode.EMPTY;

            Material spawnMat = new Material(_powerupBase);
            if (_baseTexture == "Tile")
                spawnMat.SetTexture("_BaseTexture", _tileBase);
            if (_baseTexture == "Hexagon")
                spawnMat.SetTexture("_BaseTexture", _hexBase);
            if (_baseTexture == "Smile")
                spawnMat.SetTexture("_BaseTexture", _smileBase);
            spawnMat.SetColor("_BaseColor", _baseColor);
            spawnMat.SetFloat("_Speed", _powerSpeed / 10);
            spawnMat.SetFloat("_Width", _powerWidth * 10);
            spawnMat.SetFloat("_Height", _powerHeight * 10);

            if (_baseModel == "Cube")
            {
                GameObject spawn = Instantiate(_cubeBase, transform.position, Quaternion.identity);
                spawn.tag = "Untagged";
                spawn.GetComponent<MeshRenderer>().material = spawnMat;
            }

            if (_baseModel == "Sphere")
            {
                GameObject spawn = Instantiate(_sphereBase, transform.position, Quaternion.identity);
                spawn.tag = "Untagged";
                spawn.GetComponent<MeshRenderer>().material = spawnMat;
            }

            if (_baseModel == "Cylinder")
            {
                GameObject spawn = Instantiate(_cylinderBase, transform.position, Quaternion.identity);
                spawn.tag = "Untagged";
                spawn.GetComponent<MeshRenderer>().material = spawnMat;
            }

            if (_baseModel == "Capsule")
            {
                GameObject spawn = Instantiate(_capsuleBase, transform.position, Quaternion.identity);
                spawn.tag = "Untagged";
                spawn.GetComponent<MeshRenderer>().material = spawnMat;
            }

            Instantiate(_puffParticle, transform.position, Quaternion.identity);
        }

        //Spawn dot matrix object
        if (_cookingMode == CookingMode.DOTMATRIX)
        {
            _cookingMode = CookingMode.EMPTY;

            Material spawnMat = new Material(_dotBase);
            if (_baseTexture == "Tile")
                spawnMat.SetTexture("_BaseTexture", _tileBase);
            if (_baseTexture == "Hexagon")
                spawnMat.SetTexture("_BaseTexture", _hexBase);
            if (_baseTexture == "Smile")
                spawnMat.SetTexture("_BaseTexture", _smileBase);
            spawnMat.SetColor("_BaseColor", _baseColor);
            spawnMat.SetFloat("_DotSize", _dotSize);
            spawnMat.SetFloat("_DotSpace", _dotSpace);

            if (_baseModel == "Cube")
            {
                GameObject spawn = Instantiate(_cubeBase, transform.position, Quaternion.identity);
                spawn.tag = "Untagged";
                spawn.GetComponent<MeshRenderer>().material = spawnMat;
            }

            if (_baseModel == "Sphere")
            {
                GameObject spawn = Instantiate(_sphereBase, transform.position, Quaternion.identity);
                spawn.tag = "Untagged";
                spawn.GetComponent<MeshRenderer>().material = spawnMat;
            }

            if (_baseModel == "Cylinder")
            {
                GameObject spawn = Instantiate(_cylinderBase, transform.position, Quaternion.identity);
                spawn.tag = "Untagged";
                spawn.GetComponent<MeshRenderer>().material = spawnMat;
            }

            if (_baseModel == "Capsule")
            {
                GameObject spawn = Instantiate(_capsuleBase, transform.position, Quaternion.identity);
                spawn.tag = "Untagged";
                spawn.GetComponent<MeshRenderer>().material = spawnMat;
            }

            Instantiate(_puffParticle, transform.position, Quaternion.identity);
        }
    }

    /// <summary>
    /// Changes the color of the shader to white
    /// </summary>
    public void ColorWhite()
    {
        _baseColor = Color.white;
        _colorText.text = "Color: White";
        _powerColorText.text = "Color: White";
        _dotColorText.text = "Color: White";
    }

    /// <summary>
    /// Changes the color of the shader to black
    /// </summary>
    public void ColorBlack()
    {
        _baseColor = Color.black;
        _colorText.text = "Color: Black";
        _powerColorText.text = "Color: Black";
        _dotColorText.text = "Color: Black";
    }

    /// <summary>
    /// Changes the color of the shader to red
    /// </summary>
    public void ColorRed() 
    {
        _baseColor = Color.red;
        _colorText.text = "Color: Red";
        _powerColorText.text = "Color: Red";
        _dotColorText.text = "Color: Red";
    }

    /// <summary>
    /// Changes the color of the shader to yellow
    /// </summary>
    public void ColorYellow()
    {
        _baseColor = Color.yellow;
        _colorText.text = "Color: Yellow";
        _powerColorText.text = "Color: Yellow";
        _dotColorText.text = "Color: Yellow";
    }

    /// <summary>
    /// Changes the color of the shader to green
    /// </summary>
    public void ColorGreen()
    {
        _baseColor = Color.green;
        _colorText.text = "Color: Green";
        _powerColorText.text = "Color: Green";
        _dotColorText.text = "Color: Green";
    }

    /// <summary>
    /// Changes the color of the shader to blue
    /// </summary>
    public void ColorBlue()
    {
        _baseColor = Color.blue;
        _colorText.text = "Color: Blue";
        _powerColorText.text = "Color: Blue";
        _dotColorText.text = "Color: Blue";
    }

    /// <summary>
    /// Changes the color of the shader to purple
    /// </summary>
    public void ColorPurple()
    {
        _baseColor = Color.magenta;
        _colorText.text = "Color: Purple";
        _powerColorText.text = "Color: Purple";
        _dotColorText.text = "Color: Purple";
    }

    /// <summary>
    /// Increase the edge width of the dissolve shader
    /// </summary>
    public void IncreaseEdge() 
    {
        _edgeWidth += 0.01f;
        if (_edgeWidth > 1.0f)
            _edgeWidth = 1.0f;
    }

    /// <summary>
    /// Decrease the edge width of the dissolve shader
    /// </summary>
    public void DecreaseEdge()
    {
        _edgeWidth -= 0.01f;
        if (_edgeWidth < 0.01f)
            _edgeWidth = 0.01f;
    }

    /// <summary>
    /// Increase the noise power in the dissolve shader
    /// </summary>
    public void IncreaseNoise()
    {
        _noisePower += 10f;
        if (_noisePower > 500f)
            _noisePower = 500f;
    }

    /// <summary>
    /// Decrease the noise power in the dissolve shader
    /// </summary>
    public void DecreaseNoise()
    {
        _noisePower -= 10f;
        if (_noisePower < 10f)
            _noisePower = 10f;
    }

    /// <summary>
    /// Increase the speed that the scroll effect happens in the power up shader
    /// </summary>
    public void IncreasePowerSpeed()
    {
        _powerSpeed += 1f;
        if (_powerSpeed > 10f)
            _powerSpeed = 10f;
    }

    /// <summary>
    /// Decrease the speed that the scroll effect happens in the power up shader
    /// </summary>
    public void DecreasePowerSpeed()
    {
        _powerSpeed -= 1f;
        if (_powerSpeed < 1f)
            _powerSpeed = 1f;
    }

    /// <summary>
    /// Increase the triangle width in the power up shader
    /// </summary>
    public void IncreasePowerWidth()
    {
        _powerWidth += 1f;
        if (_powerWidth > 10f)
            _powerWidth = 10f;
    }

    /// <summary>
    /// Decrease the triangle width in the power up shader
    /// </summary>
    public void DecreasePowerWidth()
    {
        _powerWidth -= 1f;
        if (_powerWidth < 1f)
            _powerWidth = 1f;
    }

    /// <summary>
    /// Increase the triangle height in the power up shader
    /// </summary>
    public void IncreasePowerHeight()
    {
        _powerHeight += 1f;
        if (_powerHeight > 10f)
            _powerHeight = 10f;
    }

    /// <summary>
    /// Decrease the triangle height in the power up shader
    /// </summary>
    public void DecreasePowerHeight()
    {
        _powerHeight -= 1f;
        if (_powerHeight < 1f)
            _powerHeight = 1f;
    }

    /// <summary>
    /// Increase the dot size in the dot matrix shader
    /// </summary>
    public void IncreaseDotSize()
    {
        _dotSize += 1f;
        if (_dotSize > 10f)
            _dotSize = 10f;
    }

    /// <summary>
    /// Decrease the dot size in the dot matrix shader
    /// </summary>
    public void DecreaseDotSize()
    {
        _dotSize -= 1f;
        if (_dotSize < 1f)
            _dotSize = 1f;
    }

    /// <summary>
    /// Increase the dot space in the dot matrix shader
    /// </summary>
    public void IncreaseDotSpace()
    {
        _dotSpace += 1f;
        if (_dotSpace > 10f)
            _dotSpace = 10f;
    }

    /// <summary>
    /// Decrease the dot space in the dot matrix shader
    /// </summary>
    public void DecreaseDotSpace()
    {
        _dotSpace -= 1f;
        if (_dotSpace < 1f)
            _dotSpace = 1f;
    }
}
