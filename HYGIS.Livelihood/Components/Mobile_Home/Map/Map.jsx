class Map extends React.Component {
    constructor(props) {
        super(props);
        this.state = {};
    }
    initMap() {
        //debugger
        //天地图加载
        var vec = L.tileLayer.TDTJX({ type: 'vec' }),
            vec_anno = L.tileLayer.TDTJX({ type: 'vec_anno' }),
            img = L.tileLayer.TDTJX({ type: 'img' }),
            img_anno = L.tileLayer.TDTJX({ type: 'img_anno' });


        var baseLayers = {
            vec: L.layerGroup([vec]),
            vec_anno: L.layerGroup([vec, vec_anno]),
            img: L.layerGroup([img]),
            img_anno: L.layerGroup([img, img_anno])
        };
        var layers = [baseLayers.vec, baseLayers.vec_anno];
        var map = L.map('map', {
            attributionControl: false,
            crs: L.CRS.EPSG4490,
            center: [30.5265465872, 120.9462728251],
            zoomControl: true,
            maxZoom: 18,
            minZoom:13,
            zoom: 13,
            layers: layers
        });

        this.map = map;
        this.$mapDom = $('#map');
        //this.addScale();
 
    }

    componentDidMount() {

        this.initMap();
    }

    addScale() {
        this.scale = L.control.scale(
            {
                position: 'bottomleft',
                imperial: false
            }).addTo(this.map);
    }

    render() {
        return (
            <div id="map" >

            </div>
        );
    }
}

