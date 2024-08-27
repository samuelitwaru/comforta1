function UCPageTree($) {

	var template = '<script src=\"https://cdn.jsdelivr.net/npm/apextree\"></script><div id=\"svg-tree\"></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts


			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();



			// Raise after show scripts
			this.Start(); 
	}

	this.Scripts = [];

		this.Start = function() {

				    const data = {
					"id": "idA",
					"name": "A",
					"children": [
						{
						"id": "idB",
						"name": "B",
						"children": [
							{
							"id": "idC",
							"name": "C"
							},
							{
								"id": "idD",
								"name": "D"
							}
						]
						}
					]
					};
					
					const options = {
					width: 700,
					height: 700,
					nodeWidth: 120,
					nodeHeight: 80,
					childrenSpacing: 100,
					siblingSpacing: 30,
					direction: 'left',
					canvasStyle: 'border: 1px solid black; background: #f6f6f6;',
					};
					
					const tree = new ApexTree(document.getElementById('svg-tree'), options);
					const graph = tree.render(data);
				
		}



	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}