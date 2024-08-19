function UCToolBox($) {

	var template = '<div id=\"gjs\" class=\"container-gjs\">			<div class=\"drop-area\" style=\"border: 1px solid #ddd; padding: 20px; min-height: 200px;\">      Drop here    </div></div>';
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

					const escapeName = (name) =&gt; `${name}`.trim().replace(/([^a-z0-9\w-:/]+)/gi, '-');

					const editor = grapesjs.init({
						cssComposer: {},
						container: '#gjs',
					  	fromElement: true,
					  	storageManager: false,
					  	selectorManager: { escapeName },
					  	plugins: ['grapesjs-tailwind'],
						  deviceManager: {
							devices: [
							{
								name: 'Mobile',
								width: '375px', // Example width for mobile
								height: '667px', // Example height for mobile
								widthMedia: '480px', // Media query for mobile view
							},
							],
						},
					});
				
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