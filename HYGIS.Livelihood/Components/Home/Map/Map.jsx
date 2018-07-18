class Map extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
        };
    }
    initMap() {
         //天地图加载

        var map = L.map('map', {
            attributionControl: false,
            crs: L.CRS.EPSG4490,
            center: [30.5265465872, 120.9462728251],
            zoomControl: false,
            maxZoom: 18,
            minZoom:3,
            zoom: 13,
        });
       
        this.map = map;

        this.Layers = L.layerGroup().addTo(this.map);

        this.Layers.addLayer(this.ReturnMapType('vector'));
        //var path = L.curve(['M', [50.54136296522163, 28.520507812500004],
        //    'C', [52.214338608258224, 28.564453125000004],
        //    [48.45835188280866, 33.57421875000001],
        //    [50.680797145321655, 33.83789062500001],
        //    'V', [48.40003249610685],
        //    'L', [47.45839225859763, 31.201171875],
        //    [48.40003249610685, 28.564453125000004], 'Z'],
        //    { color: 'red', fill: true }).addTo(this.map);
        //L.circle([30.5265465872, 120.9462728251], { radius: 900 }).addTo(this.map);
        this.$mapDom = $('#map');
        this.addScale();
        this.initMeasureTool();
    }

    ReturnMapType = (type) => {
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
        if (type == 'vector') return baseLayers.vec_anno;
        if (type == 'image') return baseLayers.img_anno;
    }
    //初始化测量工具
    initMeasureTool=()=> {
        L.Draw.resetMeasureDrawLocal();
        this.measureTool = L.drawTool(this.map, { showMeasure: true });
        this.measureTool.on('drawcomplete', function (e) {
            var layer = e.layer;
            this.measureLayer.addLayer(layer);
            this.showMeasureResult(layer);
        }.bind(this), false);
    }

    componentDidMount() {

        this.initMap();
    }

    componentWillReceiveProps = (nextProps) => {
        let self = this;

        if (self.props.vectorOrImage != nextProps.vectorOrImage) {

            if (nextProps.vectorOrImage) {
                self.Layers.clearLayers();
                self.Layers.addLayer(self.ReturnMapType('vector'));
            }
            if (!nextProps.vectorOrImage) {
                self.Layers.clearLayers();
                self.Layers.addLayer(self.ReturnMapType('image'));
            }
        }

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

